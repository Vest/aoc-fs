module aoc.year2022.Day2

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Winner =
    | PlayerWon
    | PlayerLost
    | Draw

type Choice =
    | Rock
    | Paper
    | Scissors

let internal playRound (elf: Choice) (player: Choice) : Winner =
    match (elf, player) with
    | (ch1, ch2) when ch1 = ch2 -> Draw
    | (Rock, Paper) -> PlayerWon
    | (Paper, Scissors) -> PlayerWon
    | (Scissors, Rock) -> PlayerWon
    | _ -> PlayerLost

let internal parseChoice c =
    match c with
    | 'A'
    | 'X' -> Some Rock
    | 'B'
    | 'Y' -> Some Paper
    | 'C'
    | 'Z' -> Some Scissors
    | _ -> None

let internal parseWinner c =
    match c with
    | 'X' -> Some PlayerLost
    | 'Y' -> Some Draw
    | 'Z' -> Some PlayerWon
    | _ -> None

let internal detectChoice c r =
    match (c, r) with
    | (Rock, PlayerWon) -> Paper
    | (Rock, PlayerLost) -> Scissors
    | (Paper, PlayerWon) -> Scissors
    | (Paper, PlayerLost) -> Rock
    | (Scissors, PlayerWon) -> Rock
    | (Scissors, PlayerLost) -> Paper
    | (_, Draw) -> c

let internal score round choice =
    let r =
        match round with
        | PlayerWon -> 6
        | PlayerLost -> 0
        | Draw -> 3

    let c =
        match choice with
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

    r + c

let internal parseFirst (input: string) : (Choice * Choice) option =
    if input.Length = 3 then
        let letter1 = input[0]
        let letter2 = input[2]

        match (parseChoice letter1, parseChoice letter2) with
        | (Some ch1, Some ch2) -> Some(ch1, ch2)
        | _ -> None
    else
        None

let internal parseSecond (input: string) : (Choice * Winner) option =
    if input.Length = 3 then
        let letter1 = input[0]
        let letter2 = input[2]

        match (parseChoice letter1, parseWinner letter2) with
        | (Some ch1, Some ch2) -> Some(ch1, ch2)
        | _ -> None
    else
        None

let answer1 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map (fun line -> parseFirst line)
    |> Seq.map (fun round ->
        match round with
        | Some(elf, player) ->
            let round = playRound elf player
            let score = score round player
            score
        | None -> 0)
    |> Seq.sum

let answer2 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map (fun line -> parseSecond line)
    |> Seq.map (fun round ->
        match round with
        | Some(elf, round) ->
            let player = detectChoice elf round
            let score = score round player
            score
        | None -> 0)
    |> Seq.sum
