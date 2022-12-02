module aoc_test.year2022.Day2Tests

open aoc.year2022.Day2
open Xunit

[<Fact>]
let ``Parse Input`` () =
    Assert.Equal(Some (Rock, Paper), parse "A Y")
    Assert.Equal(Some (Paper, Rock), parse "B X")
    Assert.Equal(Some (Scissors, Scissors), parse "C Z")
    Assert.Equal(None, parse "C W")
    Assert.Equal(None, parse "XY")
    Assert.Equal(None, parse "XYZAB")

[<Fact>]
let ``First Answer`` () =
    Assert.Equal(15, answer1 "A Y\nB X\nC Z")
