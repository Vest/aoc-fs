module aoc_test.year2022.Day3Tests

open aoc.year2022.Day3
open Xunit

[<Fact>]
let ``Test priorities`` () =
    Assert.Equal(16, priority 'p')
    Assert.Equal(38, priority 'L')
    Assert.Equal(19, priority 's')
    Assert.Equal(0, priority 'Ы')

[<Fact>]
let ``Find common items in rucksack`` () =
    Assert.Equal(Some 'p', findCommonItem "vJrwpWtwJgWrhcsFMMfFFhFp")
    Assert.Equal(Some 'L', findCommonItem "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")
    Assert.Equal(Some 'P', findCommonItem "PmmdzqPrVvPwwTWBwg")
    Assert.Equal(Some 'v', findCommonItem "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn")
    Assert.Equal(Some 't', findCommonItem "ttgJtRGJQctTZtZT")
    Assert.Equal(Some 's', findCommonItem "CrZsJsPPZsGzwwsLwLmpwMDw")

[<Fact>]
let ``First Answer`` () =
    Assert.Equal(
        157,
        answer1
            "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw"
    )

[<Fact>]
let ``Find common items in three rucksacks`` () =
    Assert.Equal(
        Some 'r',
        findCommonItemAmongThree (
            [ "vJrwpWtwJgWrhcsFMMfFFhFp"
              "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
              "PmmdzqPrVvPwwTWBwg" ]
        )
    )

[<Fact>]
let ``Second Answer`` () =
    Assert.Equal(
        70,
        answer2
            "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw"
    )
