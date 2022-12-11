module aoc.year2022.Day10

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Instruction =
    | NOOP
    | ADDX of x: int

type CPU = { x: int }

let internal parseLine (line: string) : Instruction =
    match line with
    | noop when line.Equals "noop" -> NOOP
    | addx when line.StartsWith "addx " ->
        let x = addx.Substring 5 |> Int32.Parse
        ADDX x
    | _ -> failwith $"Unknown instruction: {line}"


let internal executeInstruction (tick: int -> CPU -> unit) (acc: int) (cpu: CPU) (inst: Instruction) : int * CPU =
    let acc = acc + 1

    match inst with
    | NOOP ->
        tick acc cpu
        acc, cpu
    | ADDX x ->
        let newCpu = { x = cpu.x + x }
        tick acc cpu
        tick (acc + 1) cpu
        (acc + 1), newCpu

let answer1 (input: string) : int =
    let mutable answer = List.empty

    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parseLine
    |> Seq.fold
        (fun (cycle, cpu) instr ->
            executeInstruction
                (fun cycle cpu ->
                    match cycle with
                    | c when (c - 20) % 40 = 0 -> answer <- cycle * cpu.x :: answer
                    | _ -> ())
                cycle
                cpu
                instr)
        (0, { x = 1 })
    |> ignore

    answer |> List.sum

let answer2 (input: string) : string =
    let mutable finalAnswer = ""
    let mutable answer = ""
    let mutable spritePos = 1

    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parseLine
    |> Seq.fold
        (fun (cycle, cpu) instr ->
            executeInstruction
                (fun cycle cpu ->
                    if cycle <> 1 && (cycle - 1) % 40 = 0 then
                        finalAnswer <- String.Concat(finalAnswer, $"{answer}{Environment.NewLine}")
                        answer <- ""

                    if abs (spritePos % 40 - cpu.x) <= 1 then
                        answer <- answer + "#"
                    else
                        answer <- answer + "."

                    spritePos <- cycle)
                cycle
                cpu
                instr)
        (0, { x = 1 })
    |> ignore

    finalAnswer <- String.Concat(finalAnswer, $"{answer}")

    finalAnswer
