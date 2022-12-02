module aoc_test.year2022.Day2Tests

open aoc.year2022.Day2
open Xunit

[<Fact>]
let ``Parse first input`` () =
    Assert.Equal(Some(Rock, Paper), parseFirst "A Y")
    Assert.Equal(Some(Paper, Rock), parseFirst "B X")
    Assert.Equal(Some(Scissors, Scissors), parseFirst "C Z")
    Assert.Equal(None, parseFirst "C W")
    Assert.Equal(None, parseFirst "XY")
    Assert.Equal(None, parseFirst "XYZAB")

[<Fact>]
let ``First Answer`` () =
    Assert.Equal(15, answer1 "A Y\nB X\nC Z")

[<Fact>]
let ``Parse second input`` () =
    Assert.Equal(Some(Rock, Draw), parseSecond "A Y")
    Assert.Equal(Some(Paper, PlayerLost), parseSecond "B X")
    Assert.Equal(Some(Scissors, PlayerWon), parseSecond "C Z")
    Assert.Equal(None, parseSecond "C W")
    Assert.Equal(None, parseSecond "XY")
    Assert.Equal(None, parseSecond "XYZAB")

[<Fact>]
let ``Second Answer`` () =
    Assert.Equal(12, answer2 "A Y\nB X\nC Z")
