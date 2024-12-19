namespace R6Ranking.wwwroot.JS
{
    function drawEloChart(labels, data) {
        const ctx = document.getElementById("eloChart").getContext("2d");

        new Chart(ctx, {
            type: "line",
            data: {
                labels: labels,
                datasets: [
                    {
                        label: "Elo History",
                        data: data,
                        borderColor: "rgba(75, 192, 192, 1)",
                        backgroundColor: "rgba(75, 192, 192, 0.2)",
                        fill: true,
                    },
                ],
            },
            options: {
                responsive: true,
                scales: {
                    x: { title: { display: true, text: "Date" } },
                    y: { title: { display: true, text: "Elo Rating" }, beginAtZero: false }
                },
            },
        });
    }

}
