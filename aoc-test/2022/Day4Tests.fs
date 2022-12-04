module aoc_test.year2022.Day4Tests

open aoc.year2022.Day4
open Xunit

[<Fact>]
let ``Test parsing`` () =
    Assert.Equal(
        { first = { left = 2; right = 4 }
          second = { left = 6; right = 8 } },
        parse "2-4,6-8"
    )

    Assert.Equal(
        { first = { left = 60; right = 60 }
          second = { left = 4; right = 6 } },
        parse "60-60,4-6"
    )

[<Fact>]
let ``Is included`` () =
    Assert.True(isIncluded { left = 2; right = 8 } { left = 3; right = 7 })
    Assert.True(isIncluded { left = 6; right = 6 } { left = 4; right = 6 })

[<Fact>]
let ``First answer`` () =
    Assert.Equal(2, answer1 "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8")

[<Fact>]
let ``Is partially included`` () =
    Assert.True(isPartiallyIncluded { left = 5; right = 7 } { left = 7; right = 9 })
    Assert.True(isPartiallyIncluded { left = 2; right = 8 } { left = 3; right = 7 })
    Assert.True(isPartiallyIncluded { left = 2; right = 6 } { left = 4; right = 8 })

[<Fact>]
let ``Second answer`` () =
    Assert.Equal(4, answer2 "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8")
