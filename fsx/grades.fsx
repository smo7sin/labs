open System
open FSharp.Collections

let gradingStudents grades = 
    grades 
    |> Seq.map (float >> Math.Ceiling >> int)

