module aoc.year2022.Day1

open System

let answer1 (input: string) : int =
    let answer =
        let index = ref 0

        input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
        |> Array.toSeq
        |> Seq.map (fun line ->
            match Int32.TryParse line with
            | true, out -> Some out
            | false, _ -> None)
        |> Seq.map (fun (calories: int option) ->
            match calories with
            | Some calories -> (index.Value, calories)
            | None ->
                index.Value <- index.Value + 1
                (index.Value, 0))
        |> Seq.groupBy fst
        |> Seq.map snd
        |> Seq.map (fun elfCalories -> elfCalories |> Seq.map snd |> Seq.sum)
        |> Seq.max

    answer

let answer2 (input: string) : int =
    let answer =
        let index = ref 0

        input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
        |> Array.toSeq
        |> Seq.map (fun line ->
            match Int32.TryParse line with
            | true, out -> Some out
            | false, _ -> None)
        |> Seq.map (fun (calories: int option) ->
            match calories with
            | Some calories -> (index.Value, calories)
            | None ->
                index.Value <- index.Value + 1
                (index.Value, 0))
        |> Seq.groupBy fst
        |> Seq.map snd
        |> Seq.map (fun elfCalories -> elfCalories |> Seq.map snd |> Seq.sum)
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.sum

    answer
