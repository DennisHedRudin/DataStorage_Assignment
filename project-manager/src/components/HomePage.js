import React from 'react';
import { Link } from 'react-router-dom'; 

function HomePage() {
    return(
        <div>
            <h1>Welcome to our project page!</h1>
            <h3>Where do you want to go?</h3>
            <div>
            <button>
                    <Link to="/projects/create">Create Project</Link>
                </button>
                <button>
                    <Link to="/projects">View Projects</Link> 
                </button>
            </div>
        </div>
        
    );
}

export default HomePage;