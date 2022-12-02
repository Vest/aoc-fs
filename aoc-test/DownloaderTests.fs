module aoc_test.DownloaderTests

open System.Net
open aoc.Downloader
open Xunit

[<Fact>]
let ``Sample URL formatting`` () =
    let url = adventUrl 2022 7
    Assert.Equal("https://adventofcode.com/2022/day/7/input", url)

[<Fact>]
let ``Empty cookie should return None`` () =
    let cookie = cookies "unknownCookie"
    Assert.Equal(None, cookie)

[<Fact>]
let ``Cookie should return Some("Cookie")`` () =
    System.Environment.SetEnvironmentVariable(advent_cookie, "Sample Cookie")
    let cookie = cookies advent_cookie
    Assert.Equal(Some("Sample Cookie"), cookie)

[<Fact>]
let ``Download with empty cookie`` () =
    let url = adventUrl 2020 7
    Assert.Throws<WebException>(fun () -> downloadUrlWithCookie "" url |> ignore)

[<Fact>]
let ``Download with any cookie`` () =
    let url = adventUrl 2020 7
    Assert.Throws<WebException>(fun () -> downloadUrlWithCookie "Test" url |> ignore)
