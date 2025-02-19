import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const ProjectList = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7120/api/project')
      .then(response => setProjects(response.data))
      .catch(error => console.error('Error fetching projects:', error));
  }, []);

  return (
    <div>
      <h1>Projects</h1>
      <Link to="/project/new">Create New Project</Link>
      <ul>
        {projects.map(project => (
          <li key={project.id}>
            {project.title} - {project.status} 
            <Link to={`/project/edit/${project.id}`}>Edit</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ProjectList;