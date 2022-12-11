module aoc_test.year2022.Day10Tests

open System
open aoc.year2022.Day10
open Xunit

let input: string =
    @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop"

[<Fact>]
let ``Parse line`` () =
    Assert.Equal(NOOP, parseLine "noop")
    Assert.Equal(ADDX 5, parseLine "addx 5")
    Assert.Equal(ADDX -50, parseLine "addx -50")


[<Fact>]
let ``CPU: noop`` () =
    let cpu = { x = 0 }
    let mutable currentCycle = 0

    let newCpu =
        NOOP |> executeInstruction (fun cycle _ -> currentCycle <- cycle) 0 cpu |> snd

    Assert.Equal(cpu, newCpu)
    Assert.Equal(1, currentCycle)

[<Fact>]
let ``CPU: addx`` () =
    let cpu = { x = 0 }
    let mutable currentCycle = 0

    let newCpu =
        ADDX 5 |> executeInstruction (fun cycle _ -> currentCycle <- cycle) 0 cpu |> snd

    Assert.Equal({ x = 5 }, newCpu)
    Assert.Equal(2, currentCycle)


[<Fact>]
let ``First Answer`` () =
    let answer = answer1 input
    Assert.Equal(13140, answer)
