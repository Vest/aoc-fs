module aoc_test.year2022.Day11Tests

open System
open aoc.year2022.Day11
open Xunit

let input: string =
    @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1"

[<Fact>]
let ``Parse monkeys`` () =
    let output = parseMonkeys input
    Assert.Equal(4, output |> Map.count)

[<Fact>]
let ``Parse monkey`` () =
    let output =
        parseMonkey
            @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3"

    Assert.Equal(0, fst output)
    Assert.Equal<Int64>([ 79L; 98L ], (snd output).items)
    Assert.Equal(23L, (snd output).divisible)
    Assert.Equal(5L * 19L, (snd output).operation 5L)
    Assert.Equal<Map<bool, int>>(Map [ (true, 2); (false, 3) ], (snd output).choice)

[<Fact>]
let ``First round`` () =
    let monkeys = parseMonkeys input
    let newMonkeys = round (fun _ _ -> ()) (fun item -> item / 3L) monkeys
    Assert.Equal<Int64>([ 20L; 23; 27; 26 ], newMonkeys.[0].items)
    Assert.Equal<Int64>([ 2080L; 25; 167; 207; 401; 1046 ], newMonkeys.[1].items)
    Assert.Equal<Int64>(List.empty, newMonkeys.[2].items)
    Assert.Equal<Int64>(List.empty, newMonkeys.[3].items)

[<Fact>]
let ``First answer`` () =
    Assert.Equal(101L * 105L, answer1 input)

[<Fact>]
let ``Second answer`` () =
    Assert.Equal(52166L * 52013L, answer2 input)
