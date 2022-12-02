module aoc_test.year2022.Day2Tests

open aoc.year2022.Day2
open Xunit

[<Fact>]
let ``Parse Input`` () =
    Assert.Equal(Some (Rock, Paper), parse "A Y")
    Assert.Equal(Some (Paper, Rock), parse "B X")
    Assert.Equal(Some (Scissors, Scissors), parse "C Z")
