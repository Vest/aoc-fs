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
    Assert.Equal(
        { head = { row = 0; col = 0 }
          tail = { row = 0; col = 0 } },
        updateTail
            { head = { row = 0; col = 0 }
              tail = { row = 0; col = 0 } }
    )

    Assert.Equal(
        { head = { row = 2; col = 2 }
          tail = { row = 2; col = 2 } },
        updateTail
            { head = { row = 2; col = 2 }
              tail = { row = 2; col = 2 } }
    )

[<Fact>]
let ``Test movements: Move right`` () =
    Assert.Equal(
        { head = { row = 0; col = 2 }
          tail = { row = 0; col = 1 } },
        updateTail
            { head = { row = 0; col = 2 }
              tail = { row = 0; col = 0 } }
    )

[<Fact>]
let ``Test movements: Move left`` () =
    Assert.Equal(
        { head = { row = 0; col = 0 }
          tail = { row = 0; col = 1 } },
        updateTail
            { head = { row = 0; col = 0 }
              tail = { row = 0; col = 2 } }
    )


[<Fact>]
let ``Test movements: Move up`` () =
    Assert.Equal(
        { head = { row = 2; col = 0 }
          tail = { row = 1; col = 0 } },
        updateTail
            { head = { row = 2; col = 0 }
              tail = { row = 0; col = 0 } }
    )

[<Fact>]
let ``Test movements: Move down`` () =
    Assert.Equal(
        { head = { row = 2; col = 0 }
          tail = { row = 1; col = 0 } },
        updateTail
            { head = { row = 2; col = 0 }
              tail = { row = 0; col = 0 } }
    )

[<Fact>]
let ``Test movements: Don't move`` () =
    Assert.Equal(
        { head = { row = 2; col = 0 }
          tail = { row = 1; col = 0 } },
        updateTail
            { head = { row = 2; col = 0 }
              tail = { row = 1; col = 0 } }
    )

    Assert.Equal(
        { head = { row = 2; col = 2 }
          tail = { row = 1; col = 1 } },
        updateTail
            { head = { row = 2; col = 2 }
              tail = { row = 1; col = 1 } }
    )

[<Fact>]
let ``Test movements: Move diagonally`` () =
    Assert.Equal(
        { head = { row = 1; col = 2 }
          tail = { row = 2; col = 2 } },
        updateTail
            { head = { row = 1; col = 2 }
              tail = { row = 3; col = 1 } }
    )

    Assert.Equal(
        { head = { row = 2; col = 3 }
          tail = { row = 2; col = 2 } },
        updateTail
            { head = { row = 2; col = 3 }
              tail = { row = 3; col = 1 } }
    )

[<Fact>]
let ``Parse line`` () =
    Assert.Equal(Right 10, parseLine "R 10")
    Assert.Equal(Left 10, parseLine "L 10")

[<Fact>]
let ``First Answer`` () = Assert.Equal(13, answer1 input)

[<Fact>]
let ``Second Answer`` () = Assert.Equal(1, answer2 input)
