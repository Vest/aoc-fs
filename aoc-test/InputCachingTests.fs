module aoc_test.InputCachingTests

open aoc.InputCaching
open Xunit

[<Fact>]
let ``Sample input path`` () =
    let path = inputFile 2022 7
    Assert.Equal("input/2022/07.txt", path)

[<Fact>]
let ``Read non-existing input`` () =
    let input = readInput 2022 7
    Assert.Equal(None, input)

[<Fact>]
let ``Read existing input`` () =
    try
        let path = inputFile 2022 7
        System.IO.Directory.CreateDirectory "input/2022" |> ignore
        System.IO.File.WriteAllText(path, "test")
        let input = readInput 2022 7

        Assert.Equal(Some "test", input)
    finally
        System.IO.Directory.Delete("input", true)

[<Fact>]
let ``Write new input and read it`` () =
    try
        writeInput 2022 7 "Test"
        let input = readInput 2022 7

        Assert.Equal(Some "Test", input)
    finally
        System.IO.Directory.Delete("input", true)

[<Fact>]
let ``Write new input and read it trimmed`` () =
    try
        writeInput 2022 7 "Test\n  "
        let input = readInput 2022 7

        Assert.Equal(Some "Test", input)
    finally
        System.IO.Directory.Delete("input", true)
