import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const ProjectList = () => {
  const [projects, setProjects] = useState([]);
  const [loading, setLoading] = useState(true);  // För att visa en laddningsindikator
  const [error, setError] = useState(null);  // För att hantera eventuella fel

  useEffect(() => {
    axios.get('https://localhost:7120/api/project')
      .then(response => {
        if (response.data && response.data.length > 0) {
          setProjects(response.data);  // Sätt projekten om det finns data
        } else {
          setProjects([]);  // Om inget finns, sätt en tom lista
        }
        setLoading(false);  // Sluta ladda
      })
      .catch(error => {
        console.error('Error fetching projects:', error);
        setError('Could not fetch projects.');  // Visa ett felmeddelande om något går fel
        setLoading(false);  // Sluta ladda
      });
  }, []);

  if (loading) {
    return <div>Loading...</div>;  // Visa en laddningsindikator om vi väntar på svar
  }

  if (error) {
    return <div>{error}</div>;  // Visa felmeddelande om något går fel
  }

  return (
    <div>
      <h1>Projects</h1>
      <Link to="/projects/create">Create New Project</Link>
      <ul>
        {projects.length === 0 ? (
          <li>No projects available.</li>  // Visa ett meddelande om inga projekt finns
        ) : (
          projects.map(project => (
            <li key={project.id}>
              {project.title} - {project.status} 
              <Link to={`/projects/edit/${project.id}`}>Edit</Link>
            </li>
          ))
        )}
      </ul>
    </div>
  );
}

export default ProjectList;