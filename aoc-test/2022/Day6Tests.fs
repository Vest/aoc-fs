module aoc_test.year2022.Day6Tests

open aoc.year2022.Day6
open Xunit

[<Fact>]
let ``Is Unique`` () =
    Assert.False(isUnique "bvwb")
    Assert.False(isUnique "mjqj")
    Assert.False(isUnique "znrn")
    Assert.True(isUnique "vwbj")

[<Fact>]
let ``Find position for 4`` () =
    Assert.Equal(7, findPosition 4 "mjqjpqmgbljsphdztnvjfqwrcgsmlb")
    Assert.Equal(5, findPosition 4 "bvwbjplbgvbhsrlpgdmjqwftvncz")
    Assert.Equal(6, findPosition 4 "nppdvjthqldpwncqszvftbrmjlhg")
    Assert.Equal(10, findPosition 4 "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")
    Assert.Equal(11, findPosition 4 "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")

[<Fact>]
let ``Find position for 14`` () =
    Assert.Equal(19, findPosition 14 "mjqjpqmgbljsphdztnvjfqwrcgsmlb")
    Assert.Equal(23, findPosition 14 "bvwbjplbgvbhsrlpgdmjqwftvncz")
    Assert.Equal(23, findPosition 14 "nppdvjthqldpwncqszvftbrmjlhg")
    Assert.Equal(29, findPosition 14 "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")
    Assert.Equal(26, findPosition 14 "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")
