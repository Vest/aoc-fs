module aoc.year2022.Day3

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let internal priority (item : char) : int =
    match item with
    | small when small >= 'a' && small <= 'z' -> Convert.ToInt32(small) - Convert.ToInt32('a') + 1
    | small when small >= 'A' && small <= 'Z' -> Convert.ToInt32(small) - Convert.ToInt32('A') + 27
    | _ -> 0

let internal findCommonItem (line : string) : char option=
    let firstHalf = line[..line.Length / 2]
    let secondHalf = line[line.Length / 2..]
    firstHalf
    |> Seq.tryFind (fun c -> secondHalf.Contains(c))

let answer1 (input : string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.choose(fun line -> findCommonItem line)
    |> Seq.map(priority)
    |> Seq.sum

let answer2 input = 0
