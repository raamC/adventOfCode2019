var fs = require("fs");
var data = fs.readFileSync("./inputs/day1_input1.txt", 'utf-8');
data = data.trim().split('\n')

function getFuelRequired(mass: number): number {
    return Math.floor(mass/3) - 2
}

var fuel = data.map(x => getFuelRequired(x))
var totalFuel = fuel.reduce((a, b) => a + b, 0)
console.log(`Part 1: ${totalFuel}`)

function getTotalFuel(mass: number): number {
    var totalFuel = 0
    var fuel = getFuelRequired(mass);
    totalFuel = totalFuel + fuel

    while(getFuelRequired(fuel) > 0) {
        fuel = getFuelRequired(fuel)
        totalFuel = totalFuel + fuel
    }

    return totalFuel
    
}

var fuel = data.map(x => getTotalFuel(x))
var totalFuel = fuel.reduce((a, b) => a + b, 0)
console.log(`Part 2: ${totalFuel}`)
