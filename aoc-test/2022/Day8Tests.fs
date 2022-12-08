module aoc_test.year2022.Day8Tests

open System
open aoc.year2022.Day8
open Xunit

let input =
    @"30373
25512
65332
33549
35390"

[<Fact>]
let ``Parse line of trees`` () =
    Assert.Equal<int>([| 3; 0; 3; 7; 3 |], parseLine "30373")

[<Fact>]
let ``Parse forest`` () =
    let forest = parseForest input

    Assert.Equal<int[]>(
        [| [| 3; 0; 3; 7; 3 |]
           [| 2; 5; 5; 1; 2 |]
           [| 6; 5; 3; 3; 2 |]
           [| 3; 3; 5; 4; 9 |]
           [| 3; 5; 3; 9; 0 |] |],
        forest
    )

[<Fact>]
let ``Is visible: edge`` () =
    let forest: Field = createField input

    [ 0..4 ]
    |> List.iter (fun i ->
        Assert.True(forest.isVisible (0, i))
        Assert.True(forest.isVisible (4, i))
        Assert.True(forest.isVisible (i, 0))
        Assert.True(forest.isVisible (i, 4)))
