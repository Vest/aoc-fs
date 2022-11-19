module aoc.InputCaching

open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let internal inputFolder (year: int) (day: int) : string = $"input/{year}/{day,2:D2}/"
