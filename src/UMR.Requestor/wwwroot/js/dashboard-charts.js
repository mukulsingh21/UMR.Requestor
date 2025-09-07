class DashboardCharts {
    constructor(completed, pending, rejected, businessAreaLabels, businessAreaValues) {
        this.completed = completed;
        this.pending = pending;
        this.rejected = rejected;
        this.businessAreaLabels = businessAreaLabels;
        this.businessAreaValues = businessAreaValues;
    }

    renderAllRequestsChart() {
        const allData = {
            labels: ['Completed', 'Pending', 'Reject'],
            datasets: [{
                data: [this.completed, this.pending, this.rejected],
                backgroundColor: ['#28a745', '#ffc107', '#dc3545'],
            }]
        };
        new Chart(document.getElementById('allRequestsChart'), { type: 'doughnut', data: allData });
    }

    renderBusinessAreaChart() {
        new Chart(document.getElementById('businessAreaChart'), {
            type: 'doughnut',
            data: {
                labels: this.businessAreaLabels,
                datasets: [{
                    data: this.businessAreaValues,
                    backgroundColor: ['#0d6efd', '#20c997', '#6610f2', '#fd7e14', '#6c757d']
                }]
            },
            options: {
                cutout: '65%',
                rotation: -90,
                circumference: 180,
                plugins: {
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });
    }

    renderAll() {
        this.renderAllRequestsChart();
        this.renderBusinessAreaChart();
    }
}
