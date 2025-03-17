function initCharts(employees, workshops) {
  const employeeParticipation = employees.map((employee) => ({
    name: employee.name,
    workshops: workshops.filter((w) => w.participants.includes(employee.id))
      .length,
  }));

  const workshopParticipation = workshops.map((workshop) => ({
    name: workshop.name,
    participants: workshop.participants.length,
  }));

  new Chart(document.getElementById("employeeChart"), {
    type: "bar",
    data: {
      labels: employeeParticipation.map((e) => e.name),
      datasets: [
        {
          label: "Workshops Participados",
          data: employeeParticipation.map((e) => e.workshops),
          backgroundColor: "rgba(37, 99, 235, 0.8)",
          borderColor: "rgba(37, 99, 235, 1)",
          borderWidth: 1,
        },
      ],
    },
    options: {
      responsive: true,
      scales: {
        y: {
          beginAtZero: true,
          ticks: {
            stepSize: 1,
          },
        },
      },
    },
  });

  new Chart(document.getElementById("workshopChart"), {
    type: "pie",
    data: {
      labels: workshopParticipation.map((w) => w.name),
      datasets: [
        {
          data: workshopParticipation.map((w) => w.participants),
          backgroundColor: [
            "rgba(37, 99, 235, 0.8)",
            "rgba(96, 165, 250, 0.8)",
            "rgba(59, 130, 246, 0.8)",
          ],
          borderColor: [
            "rgba(37, 99, 235, 1)",
            "rgba(96, 165, 250, 1)",
            "rgba(59, 130, 246, 1)",
          ],
          borderWidth: 1,
        },
      ],
    },
    options: {
      responsive: true,
      plugins: {
        legend: {
          position: "bottom",
        },
      },
    },
  });
}

export { initCharts };
