//these are similar to C# using statements
open canopy
open runner
open System
open configuration
open reporters


 
let baseUrl = "http://localhost:1854" 
chromeDir <- "C:\\chromedriver" 
start chrome


"Log in" &&& fun _ ->
    url (baseUrl + "/Account/Login")
    "#Email" << "suthep@gfbd.co.th"
    "#Password" << "Test999/*"
    click "input[type=submit]"
    on baseUrl
 
"Click add link then go to create page" &&& fun _ ->
    url (baseUrl + "/cars")
    displayed "a#gotoAdd"
    click "a#gotoAdd"
    on (baseUrl + "/cars/create")
 
"Add new car" &&& fun _ ->
    let make = "Tesla " + DateTime.Now.Ticks.ToString()
    url (baseUrl + "/cars/create")
    "#Make" << make
    "#Model" << "Model 3"
    click "button#btnAdd"
 
    on (baseUrl + "/cars")
    "td" *= make

"Add new car" &&& fun _ ->
    let make = "Tesla " + DateTime.Now.Ticks.ToString()
    url (baseUrl + "/cars/create")
    "#Make" << make
    "#Model" << "Model 3"
    click "button#btnAdd"
 
    on (baseUrl + "/cars")
    "td" *= make
 
"Add the third car should failed" &&& fun _ ->
    let make = "Tesla " + DateTime.Now.Ticks.ToString()
    url (baseUrl + "/cars/create")
    "#Make" << make
    "#Model" << "Model 3"
    click "button#btnAdd"
 
    on (baseUrl + "/cars")
    "td" *!= make
    contains "Cannot add more car" (read ".error")


run() 
//printfn "press [enter] to exit"
//System.Console.ReadLine() |> ignore 
quit()