module aoc.Downloader

open FSharp.Data

let private adventUrl (year : uint, day : uint) : string = $"https://adventofcode.com/{year}/day/{day}/input"
let private cookies =
    try
        Some(System.Environment.GetEnvironmentVariable "ADVENT_SESSION")
    with
        | None
let inputData year day =
    match cookies with
    | Some(cookies) -> Http.RequestString (url = adventUrl (year day), cookies = ["session", cookies])
    | _ -> ""

