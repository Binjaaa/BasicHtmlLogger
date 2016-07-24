$(document).ready(function(){
	var ctx = $("#chartCanvas").get(0).getContext("2d");

	var data = [
		{
			value: 270,
			color: "cornflowerblue",
			highlight: "lightskyblue",
			label: "JavaScript"
		},
		{
			value: 50,
			color: "lightgreen",
			highlight: "yellowgreen",
			label: "HTML"
		},
		{
			value: 40,
			color: "orange",
			highlight: "darkorange",
			label: "CSS"
		}
	];

	var chart = new Chart(ctx).Doughnut(data);
});

var config = {
    type: 'pie',
    data: {
        datasets: [{
            data: [
                pAmt,
                iAmt,
                pFee
            ],
            backgroundColor: [
                "#F7464A",
                "#46BFBD",
                "#FDB45C"
            ],
        }],
        labels: [
            "Principal Amount",
            "Interest Amount",
            "Processing Fee"
        ]
    },
        options: {
        responsive: true
    }
};

window.onload = function() {
    var ctx = document.getElementById("emichart").getContext("2d");
    window.myPie = new Chart(ctx, config);
};
