import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import { getAllProjects, deleteProject } from "../services/projectService";

const ProjectListPage = () => {
  const [projects, setProjects] = useState([]);

  
  const handleDeleteProject = async (id) => {
    try {
      
      await deleteProject(id);

      
      setProjects(projects.filter((project) => project.id !== id));
    } catch (error) {
      console.error("Error deleting project", error);
    }
  };

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const data = await getAllProjects(); 
        setProjects(data);
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
            <th>Product</th>
            <th>Price</th>
            <th>Customer</th>                      
            <th>Employee</th>
          </tr>
        </thead>
        <tbody>
          {projects.map((project) => (
            <tr key={project.id}>
              <td>{project.title}</td>
              <td>{project.startDate}</td>
              <td>{project.endDate}</td>
              <td>{project.status?.statusName || "N/A"}</td>              
              <td>{project.product?.productName || "N/A"}</td>
              <td>{project.product?.price || "N/A"}</td>
              <td>{project.customer?.customerName || "N/A"}</td>
              <td>{project.user?.firstName || "N/A"}</td>
              <td>
                <button>
                    <Link to={`/projects/edit/${project.id}`}>Edit Project</Link>
                </button>                
                <button onClick={() => handleDeleteProject(project.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProjectListPage;