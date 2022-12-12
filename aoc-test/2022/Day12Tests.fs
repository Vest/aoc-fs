module aoc_test.year2022.Day12Tests

open aoc.year2022.Day12
open Xunit

[<Fact>]
let ``Parse land to array`` () =
    let input: string = "abc\ncde"
    Assert.Equal<char[]>([| [| 'a'; 'b'; 'c' |]; [| 'c'; 'd'; 'e' |] |], parseLandToArray input)
