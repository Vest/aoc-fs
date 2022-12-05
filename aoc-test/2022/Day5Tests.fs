module aoc_test.year2022.Day5Tests

open aoc.year2022.Day5
open Xunit

[<Fact>]
let ``Parse line of crates`` () =
    let input = parseCrates "[Z] [M] [P]" |> Array.toSeq
    let output = [|Crate 'Z'; Crate 'M'; Crate 'P'|] |> Array.toSeq
    Assert.Equal (output |> Seq.length, input |> Seq.length)
    output
    |> Seq.zip input
    |> Seq.iter Assert.Equal
