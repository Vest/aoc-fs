module aoc_test.year2022.Day9Tests

open System
open aoc.year2022.Day9
open Xunit

let input: string =
    @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2"

[<Fact>]
let ``Test movements: Start-Stop`` () =
    Assert.Equal({ row = 0; col = 0 }, updateKnot { row = 0; col = 0 } { row = 0; col = 0 })
    Assert.Equal({ row = 2; col = 2 }, updateKnot { row = 2; col = 2 } { row = 2; col = 2 })

[<Fact>]
let ``Test movements: Move right`` () =
    Assert.Equal({ row = 0; col = 1 }, updateKnot { row = 0; col = 2 } { row = 0; col = 0 })

[<Fact>]
let ``Test movements: Move left`` () =
    Assert.Equal({ row = 0; col = 1 }, updateKnot { row = 0; col = 0 } { row = 0; col = 2 })

[<Fact>]
let ``Test movements: Move up`` () =
    Assert.Equal({ row = 1; col = 0 }, updateKnot { row = 2; col = 0 } { row = 0; col = 0 })

[<Fact>]
let ``Test movements: Move down`` () =
    Assert.Equal({ row = 1; col = 0 }, updateKnot { row = 0; col = 0 } { row = 2; col = 0 })

[<Fact>]
let ``Test movements: Don't move`` () =
    Assert.Equal({ row = 1; col = 0 }, updateKnot { row = 2; col = 0 } { row = 1; col = 0 })
    Assert.Equal({ row = 1; col = 1 }, updateKnot { row = 2; col = 2 } { row = 1; col = 1 })

[<Fact>]
let ``Test movements: Move diagonally`` () =
    Assert.Equal({ row = 2; col = 2 }, updateKnot { row = 1; col = 2 } { row = 3; col = 1 })
    Assert.Equal({ row = 2; col = 2 }, updateKnot { row = 2; col = 3 } { row = 3; col = 1 })

[<Fact>]
let ``Parse line`` () =
    Assert.Equal(Right 10, parseLine "R 10")
    Assert.Equal(Left 10, parseLine "L 10")

[<Fact>]
let ``First Answer`` () = Assert.Equal(13, answer1 input)

[<Fact>]
let ``Second Answer: Simple`` () = Assert.Equal(1, answer2 input)

[<Fact>]
let ``Second Answer: Advanced`` () =
    let input =
        @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20"

    Assert.Equal(36, answer2 input)
