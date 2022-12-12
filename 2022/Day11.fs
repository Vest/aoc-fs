module aoc.year2022.Day11

open System
open System.Runtime.CompilerServices
open System.Text.RegularExpressions
open Microsoft.FSharp.Core.Operators.Checked

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Monkey =
    { mutable items: int64 list
      operation: int64 -> int64
      divisible: int64
      choice: Map<bool, int> }

let internal indexRegex = Regex("^Monkey (\d+):.*", RegexOptions.Compiled)

let internal parseOperation (input: string) : (int64 -> int64) =
    match input with
    | line when line.Contains("old * old") -> (fun x -> x * x)
    | line when line.StartsWith("new = old * ") ->
        let num = input.Substring("new = old * ".Length) |> Int64.Parse
        (fun x -> x * num)
    | line when line.StartsWith("new = old / ") ->
        let num = input.Substring("new = old / ".Length) |> Int64.Parse
        (fun x -> x / num)
    | line when line.StartsWith("new = old - ") ->
        let num = input.Substring("new = old - ".Length) |> Int64.Parse
        (fun x -> x - num)
    | line when line.StartsWith("new = old + ") ->
        let num = input.Substring("new = old + ".Length) |> Int64.Parse
        (fun x -> x + num)
    | _ -> failwithf $"This expression is unknown: {input}"

let internal parseMonkey (input: string) : int * Monkey =
    let lines = input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)

    let indexMatch = indexRegex.Match(lines[0])
    let index = indexMatch.Groups[1].Value |> Int32.Parse

    let items =
        lines[1]
            .Substring("  Starting items: ".Length)
            .Split(", ", StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
        |> Array.toList
        |> List.map Int64.Parse

    let operation = lines[ 2 ].Substring("  Operation: ".Length) |> parseOperation
    let divisible = lines[ 3 ].Substring("  Test: divisible by ".Length) |> Int64.Parse

    let ifTrue =
        lines[ 4 ].Substring("    If true: throw to monkey ".Length) |> Int32.Parse

    let ifFalse =
        lines[ 5 ].Substring("    If false: throw to monkey ".Length) |> Int32.Parse

    index,
    { items = items
      operation = operation
      divisible = divisible
      choice = Map [ (true, ifTrue); (false, ifFalse) ] }

let internal parseMonkeys (input: string) : Map<int, Monkey> =
    input.Split([| "\r\n\r\n"; "\n\n" |], StringSplitOptions.None)
    |> Array.toList
    |> List.map parseMonkey
    |> Map.ofList

let internal round
    (tick: int -> Monkey -> unit)
    (calcWorry: int64 -> int64)
    (state: Map<int, Monkey>)
    : Map<int, Monkey> =
    let maxKey = state.Keys |> Seq.max
    let mutable state = state

    [ 0..maxKey ]
    |> List.iter (fun index ->
        let monkey = state.[index]

        tick index monkey |> ignore

        monkey.items
        |> List.iter (fun item ->
            let worryLevel: int64 = monkey.operation item |> calcWorry
            let isDivisible: bool = (worryLevel % monkey.divisible) = 0
            let newMonkey = state.[monkey.choice.[isDivisible]]
            newMonkey.items <- newMonkey.items @ [ worryLevel ])

        monkey.items <- List.empty)

    state

let answer1 (input: string) : int64 =
    let monkeys = parseMonkeys input
    let mutable itemsCount = Array.init monkeys.Count (fun _ -> 0L)

    seq { 1..20 }
    |> Seq.scan
        (fun monkeys _ ->
            round
                (fun index monkey -> itemsCount[index] <- itemsCount[index] + int64 monkey.items.Length)
                (fun item -> item / 3L)
                monkeys)
        monkeys
    |> Seq.length
    |> ignore

    itemsCount |> Array.sortDescending |> Array.take 2 |> Array.fold (*) 1

let answer2 input =
    let monkeys = parseMonkeys input

    let period =
        seq { 0 .. monkeys.Count - 1 }
        |> Seq.map (fun i ->
            let monkey = monkeys.[i]
            monkey.divisible)
        |> Seq.fold (*) 1L

    let mutable itemsCount = Array.init monkeys.Count (fun _ -> 0L)

    seq { 1..10000 }
    |> Seq.scan
        (fun monkeys r ->
            round
                (fun index monkey -> itemsCount[index] <- itemsCount[index] + int64 monkey.items.Length)
                (fun item -> item % period)
                monkeys)
        monkeys
    |> Seq.length
    |> ignore

    itemsCount |> Array.sortDescending |> Array.take 2 |> Array.fold (*) 1L
