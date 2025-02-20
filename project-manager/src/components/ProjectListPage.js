import React, { useEffect, useState } from "react";
import { getAllProjects } from "../services/projectService";

const ProjectListPage = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const data = await getAllProjects(); // API-anrop för att hämta projekt
        setProjects(data); // Sätt projekten i state
      } catch (error) {
        console.error("Error fetching projects", error);
      }
    };

    fetchProjects();
  }, []);

  return (
    <div>
      <h1>Project List</h1>
      <table>
        <thead>
          <tr>
            <th>Project Title</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <tr key={project.id}>
              <td>{project.title}</td>
              <td>{project.startDate}</td>
              <td>{project.endDate}</td>
              <td>{project.status?.statusName || "N/A"}</td>
              <td>
                <button>Edit</button>
                <button>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProjectListPage;