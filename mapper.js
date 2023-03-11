// Refactored code:
const fetchData = async () => {
    const response = await fetch("mapFile.txt");
    const file = await response.text();
    const lines = file.split("\n");
    const mature = 21;
    const map = new Map();
    var maxDays = 0;
    var green = "rgba(56, 120, 3, 0.9)";
    var lightGreen = "rgba(56, 120, 3, 0.2)"

    // Loop through lines and populate map with character and days.
    for (var line of lines) {
        var [character, days] = line.split("\t");
        // Clean
        character = character.replace(/\s*\[.*?\]\s*/g, '');
        // Get max days.
        if (days > maxDays)
        {
            maxDays = days;
        }

        map.set(character, days);
    }

    // Loop through inner div elements and apply appropriate background color.
    const containerDiv = document.getElementById("grid");
    const innerDivs = containerDiv.getElementsByTagName("DIV");

    var yellow = d3.scaleLinear().domain([1,20]).range(["rgba(246,190,0,0.2)", "rgba(246,190,0,0.9)"]);
    var green = d3.scaleLinear().domain([mature, maxDays]).range([lightGreen, green]);

    for (const innerDiv of innerDivs) {
        const currentValue = parseInt(map.get(innerDiv.textContent));
        
        if (currentValue >= mature)
        {
            innerDiv.style.backgroundColor = green(currentValue);
        } 
        else if (currentValue > 0 && currentValue < mature) 
        {
            innerDiv.style.backgroundColor = yellow(currentValue);
        } 
        else if (currentValue === 0) 
        {
            innerDiv.style.backgroundColor = "rgba(255, 0, 0, 0.2)";
        } 
        else
         {
            innerDiv.style.backgroundColor = "White";
        }
    }
};

fetchData();