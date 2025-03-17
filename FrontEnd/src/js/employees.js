import { formatDate } from "./dateUtils.js";

function renderEmployees(employees) {
  const employeesList = document.getElementById("employees-list");
  employeesList.innerHTML = employees
    .map(
      (employee) => `
        <div class="employee-item">
            <h3 class="employee-name">${employee.name}</h3>
            <p class="employee-id">ID: ${employee.id}</p>
        </div>
    `
    )
    .join("");
}

export { renderEmployees };
