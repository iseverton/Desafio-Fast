import { formatDate } from "./dateUtils.js";

function renderWorkshops(workshops, employees) {
  const workshopsList = document.getElementById("workshops-list");
  workshopsList.innerHTML = workshops
    .map(
      (workshop) => `
        <div class="workshop-item" data-id="${workshop.id}">
            <div class="workshop-header">
                <div>
                    <h3 class="workshop-title">${workshop.name}</h3>
                    <p class="workshop-date">${formatDate(workshop.date)}</p>
                </div>
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="chevron-down"><polyline points="6 9 12 15 18 9"></polyline></svg>
            </div>
            <div class="workshop-details">
                <p class="workshop-description">${workshop.description}</p>
                <div class="participants-list">
                    <h4 class="participants-title">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M22 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/></svg>
                        Participantes
                    </h4>
                    ${workshop.participants
                      .map((participantId) => {
                        const participant = employees.find(
                          (emp) => emp.id === participantId
                        );
                        return `<div class="participant-item">${participant.name}</div>`;
                      })
                      .join("")}
                </div>
            </div>
        </div>
    `
    )
    .join("");

  document.querySelectorAll(".workshop-item").forEach((item) => {
    item.addEventListener("click", () => {
      const details = item.querySelector(".workshop-details");
      details.classList.toggle("active");
    });
  });
}

export { renderWorkshops };
