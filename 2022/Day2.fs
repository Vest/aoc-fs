module aoc.year2022.Day2

open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Winner =
    | Win
    | Lost
    | Draw

type Choice =
    | Rock
    | Paper
    | Scissors

let internal playRound (elf :Choice) (player : Choice) : Winner =
    match (elf, player) with
    | (ch1, ch2) when ch1 = ch2 -> Draw
    | (Rock, Paper) -> Win
    | (Paper, Scissors) -> Win
    | (Scissors, Rock) -> Win
    | _ -> Lost

let internal parseChoice c =
    match c with
    | 'A' | 'X' -> Some Rock
    | 'B' | 'Y' -> Some Paper
    | 'C' | 'Z' -> Some Scissors
    | _ -> None

let internal parse (input : string) : (Choice * Choice) option =
    if input.Length = 3 then
        let letter1 = input[0]
        let letter2 = input[2]
        match (parseChoice letter1, parseChoice letter2) with
        | (Some ch1, Some ch2) -> Some (ch1, ch2)
        | _ -> None
    else
        None

let answer1 (input: string) : int = 0

let answer2 (input: string) : int = 0
