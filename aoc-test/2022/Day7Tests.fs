module aoc_test.year2022.Day7Tests

open aoc.year2022.Day7
open Xunit

[<Fact>]
let ``Parse Line: dir`` () =
    let parsedLine = parseListLine "dir a"

    Assert.Equal(
        { Name = "a"
          Kind = Folder
          Children = [] },
        parsedLine
    )

    Assert.Equal(0, parsedLine.Size)

[<Fact>]
let ``Parse Line: file`` () =
    let parsedLine = parseListLine "14848514 b.txt"

    Assert.Equal(
        { Name = "b.txt"
          Kind = File 14848514
          Children = [] },
        parsedLine
    )

    Assert.Equal(14848514, parsedLine.Size)
