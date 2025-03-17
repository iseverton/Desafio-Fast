const employees = [
  { id: 1, name: "João Silva" },
  { id: 2, name: "Maria Oliveira" },
  { id: 3, name: "Carlos Souza" },
  { id: 4, name: "Ana Costa" },
  { id: 5, name: "Pedro Rocha" },
  { id: 6, name: "Luiza Mendes" },
];

const workshops = [
  {
    id: 1,
    name: "Workshop de React",
    date: "2025-03-23",
    description: "Aprenda os fundamentos do React.",
    participants: [1, 2],
  },
  {
    id: 8,
    name: "Oratória e Apresentações em Público",
    date: "2025-06-15",
    description: "Como falar em público com confiança e clareza.",
    participants: [1, 3, 6],
  },
  {
    id: 2,
    name: "Workshop de Node.js",
    date: "2025-04-05",
    description: "Desenvolvimento de APIs com Node.js.",
    participants: [2, 3],
  },
  {
    id: 3,
    name: "Workshop de Feedback Eficaz",
    date: "2025-04-10",
    description: "Aprenda a dar e receber feedback de forma construtiva.",
    participants: [3, 5, 6, 4],
  },
];

export { employees, workshops };
