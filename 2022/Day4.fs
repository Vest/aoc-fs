module aoc.year2022.Day4

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Range = { left: int; right: int }
type Elves = { first: Range; second: Range }

let internal parse (line: string) : Elves =
    let charDigits = line.Split([| "-"; "," |], StringSplitOptions.None)

    let range1 =
        { left = charDigits[0] |> int
          right = charDigits[1] |> int }

    let range2 =
        { left = charDigits[2] |> int
          right = charDigits[3] |> int }

    { first = range1; second = range2 }

let internal isIncluded first second =
    List.contains second.left [ first.left .. first.right ]
    && List.contains second.right [ first.left .. first.right ]
    || List.contains first.left [ second.left .. second.right ]
       && List.contains first.right [ second.left .. second.right ]

let internal isPartiallyIncluded first second =
    List.contains second.left [ first.left .. first.right ]
    || List.contains second.right [ first.left .. first.right ]
    || List.contains first.left [ second.left .. second.right ]
    || List.contains first.right [ second.left .. second.right ]

let answer1 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parse
    |> Seq.filter (fun elves -> isIncluded elves.first elves.second)
    |> Seq.length

let answer2 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parse
    |> Seq.filter (fun elves -> isPartiallyIncluded elves.first elves.second)
    |> Seq.length
