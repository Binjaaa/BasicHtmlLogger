    var getError = function() {
        var allError = document.getElementsByClassName('label-danger').length;
        return allError;
    };
    var getWarning = function() {
        var allWarning = document.getElementsByClassName("label-warning").length;
        return allWarning;
    };
    var getInfo = function() {
        var allInfo = document.getElementsByClassName("label-default").length;
        return allInfo;
    };

    var chartData = {
    labels: [
        "Error",
        "Info",
        "Warning"
    ],
    datasets: [
        {
            data: 
            [
            getError(),
            getInfo(), 
            getWarning()
            ],
            backgroundColor: [
                "#FF6384",
                "#36A2EB",
                "#FFCE56"
            ],
            hoverBackgroundColor: [
                "#FF6384",
                "#36A2EB",
                "#FFCE56"
            ]
        }]
    };

    var chartOptions = {
        responsive: true,
        maintainsAspectRation: true
    };

    window.onload = function() {

        var ctx = document.getElementById("chartCanvas").getContext("2d");
        window.myDoughnut = new Chart(ctx, {
            type: 'doughnut',
            data: chartData,
            options : chartOptions
        })
    };