module aoc_test.year2022.Day7Tests

open System
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

[<Fact>]
let ``Parse folder`` () =
    let files: Node list = buildFolder [ "dir e"; "29116 f"; "2557 g"; "62596 h.lst" ]

    Assert.Equal<Node>(
        [ { Name = "e"
            Kind = Folder
            Children = [] }
          { Name = "f"
            Kind = File 29116
            Children = [] }
          { Name = "g"
            Kind = File 2557
            Children = [] }
          { Name = "h.lst"
            Kind = File 62596
            Children = [] } ],
        files
    )

[<Fact>]
let ``Build current folder`` () =
    let input: string =
        @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k"

    let inputList =
        input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None) |> Array.toList

    let result = inputList |> getCurrentFolder 0 |> snd
    printf "%A" result
    ()

[<Fact>]
let ``First Answer`` () =
    let input: string =
        @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k"

    Assert.Equal(95437, answer1 input)

[<Fact>]
let ``Second Answer`` () =
    let input: string =
        @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k"

    Assert.Equal(24933642, answer2 input)
