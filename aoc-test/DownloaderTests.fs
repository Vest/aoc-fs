module aoc_test.DownloaderTests

open aoc.Downloader
open Xunit

[<Fact>]
let sampleAocUrl() =
    let url = aoc.Downloader.adventUrl 2022 7
    Assert.Equal(url, "https://adventofcode.com/2022/day/7/input")