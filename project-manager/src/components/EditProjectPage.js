import React, { useEffect, useState } from "react";
import { getProjectById, updateProject } from "../services/projectService";
import { useParams, useNavigate } from "react-router-dom"; // Ändra till useNavigate istället för useHistory

const EditProjectPage = () => {
  const [project, setProject] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate(); // Använd useNavigate här också

  useEffect(() => {
    const fetchProject = async () => {
      const data = await getProjectById(id);
      setProject(data);
    };

    fetchProject();
  }, [id]);

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      await updateProject(id, project);
      navigate("/projects"); // Använd navigate här också
    } catch (error) {
      console.error("Error updating project", error);
    }
  };

  if (!project) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>Edit Project</h1>
      <form onSubmit={handleUpdate}>
        <label>
          Project Title:
          <input
            type="text"
            value={project.title}
            onChange={(e) => setProject({ ...project, title: e.target.value })}
          />
        </label>
        <label>
          Start Date:
          <input
            type="date"
            value={project.startDate}
            onChange={(e) => setProject({ ...project, startDate: e.target.value })}
          />
        </label>
        <label>
          End Date:
          <input
            type="date"
            value={project.endDate}
            onChange={(e) => setProject({ ...project, endDate: e.target.value })}
          />
        </label>
        <button type="submit">Update Project</button>
      </form>
    </div>
  );
};

export default EditProjectPage;