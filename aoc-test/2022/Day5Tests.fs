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
    let input =
        parseCargo [ "    [D]    "; "[N] [C]    "; "[Z] [M] [P]"; " 1   2   3 "; "" ]

    let output =
        [ [ Crate 'N'; Crate 'Z' ]
          [ Crate 'M'; Crate 'C'; Crate 'D' ]
          [ Crate 'P'  ] ]

    Assert.Equal(output |> Seq.length, input |> Seq.length)

[<Fact>]
let ``Parse movements`` () =
    let input =
        parseMovements [ " 1   2   3 "; "move 1 from 2 to 1"; "move 3 from 1 to 3" ]

    let output =
        [ { countCrates = 1
            fromPile = 2
            toPile = 1 }
          { countCrates = 3
            fromPile = 1
            toPile = 3 } ]

    Assert.Equal(output |> Seq.length, input |> Seq.length)
    Assert.Equal(output, input)

[<Fact>]
let ``Convert cargo to Map`` () =
    let input = convertCargoToMap [ [ Crate 'A' ]; [ Crate 'B' ] ]
    let output = Map [ (1, [| Crate 'A' |]); (2, [| Crate 'B' |]) ]
    Assert.Equal(output.[1], input.[1])
    Assert.Equal(output.[2], input.[2])

[<Fact>]
let ``Pop cargo from Map`` () =
    let cargo = Map [ (1, [ Crate 'A' ]); (2, [ Crate 'B' ]) ]
    let input = popFromPile cargo 1

    let output =
        (Crate 'A',
         Map[(1, [])
             (2, [ Crate 'B' ])])

    Assert.Equal(output, input)
