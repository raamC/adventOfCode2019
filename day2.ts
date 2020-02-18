var fs = require("fs");
var data = fs.readFileSync("./day2_input1.txt", 'utf-8');
data = data.trim().split(',')
data = data.map(x => Number(x))

data[1] = 12
data[2] = 2

function compute(data: Array<number>): Array<number> {
    let i = 0
    while (i < data.length ) {
        if (data[i] == 99){
            break;
        }
    
        if(data[i] == 1) {
            data[data[i + 3]] = data[data[i+1]] + data[data[i+2]]
            i = i + 4
        }
    
        if(data[i] == 2) {
            data[data[i + 3]] = data[data[i+1]] * data[data[i+2]]
            i = i + 4
        }
        continue;
    
    }
    return data
}

var answer = compute(data)[0]

console.log(`Part 1: ${answer}`)

loop1: 
for(let p = 0; p < 100; p++) {

    loop2: 
    for(let q = 0; q < 100; q++) {
        
        var data = fs.readFileSync("./day2_input1.txt", 'utf-8');
        data = data.trim().split(',')
        data = data.map(x => Number(x))
        
        data[1] = p
        data[2] = q

        var computedData = compute(data)
        
        if (computedData[0] == 19690720 ){
            console.log(`Part 2: ${100 * p + q}`)
            break loop1;
        }
    }
}
