module aoc_test.year2022.Day12Tests

open aoc.year2022.Day12
open Xunit

let input: string =
    @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi"

[<Fact>]
let ``Parse land to array`` () =
    let input: string = "abc\ncde"
    let output = parseLandToArray input
    Assert.Equal<char[]>([| [| 'a'; 'b'; 'c' |]; [| 'c'; 'd'; 'e' |] |], output)
    Assert.Equal<char>([| 'a'; 'b'; 'c' |], output[0])
    Assert.Equal<char>('c', output[0][2])

[<Fact>]
let ``Can move`` () =
    Assert.True(canMove 'a' 'a')
    Assert.True(canMove 'a' 'b')
    Assert.False(canMove 'a' 'c')
    Assert.True(canMove 'b' 'a')
    Assert.True(canMove 'c' 'a')
    Assert.True(canMove 'z' 'E')
    Assert.False(canMove 'y' 'E')
    Assert.True(canMove 'a' 'S')
    Assert.True(canMove 'b' 'S')
    Assert.True(canMove 'S' 'a')

[<Fact>]
let ``Find neighbours`` () =
    let input = parseLandToArray input

    Assert.Equal<Coord>(
        Set.empty.Add({ row = 1; col = 0 }).Add({ row = 0; col = 1 }),
        gatherNeighbours input { row = 0; col = 0 }
    )
