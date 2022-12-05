module aoc_test.year2022.Day5Tests

open aoc.year2022.Day5
open Xunit

[<Fact>]
let ``Parse line of crates`` () =
    let input = parseCrates "[Z] [M] [P]" |> Array.toSeq
    let output = [| Crate 'Z'; Crate 'M'; Crate 'P' |] |> Array.toSeq
    Assert.Equal(output |> Seq.length, input |> Seq.length)
    output |> Seq.zip input |> Seq.iter Assert.Equal

[<Fact>]
let ``Parse line of crates with holes`` () =
    let input = parseCrates "[N] [C]    " |> Array.toSeq
    let output = [| Crate 'N'; Crate 'C'; Empty |] |> Array.toSeq
    Assert.Equal(output |> Seq.length, input |> Seq.length)
    output |> Seq.zip input |> Seq.iter Assert.Equal

[<Fact>]
let ``Parse cargo`` () =
    let input = parseCargo ["    [D]    ";"[N] [C]    ";"[Z] [M] [P]"; " 1   2   3 "; ""]
    let output = [[Empty; Crate 'D'; Empty]; [Crate 'N'; Crate 'C'; Empty];[Crate 'Z'; Crate 'M'; Crate 'P']]
    Assert.Equal(output |> Seq.length, input |> Seq.length)
