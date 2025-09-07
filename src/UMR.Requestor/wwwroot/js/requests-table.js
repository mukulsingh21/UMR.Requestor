// Initialize DataTable for requests grid
function initRequestsGrid() {
    $('#requestsGrid').DataTable({
        responsive: true,
        order: [], // No initial sort
        language: {
            search: "Filter:"
        },
        // Move length selector below table but above pagination
        dom: 'frt<"row mb-2"l>ip'
    });
}
