module aoc_test.InputCachingTests

open aoc.InputCaching
open Xunit

[<Fact>]
let ``Sample Input formatting`` () =
    let url = inputFolder 2022 7
    Assert.Equal("input/2022/07/", url)
