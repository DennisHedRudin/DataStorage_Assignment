import React from 'react';
import { Link } from 'react-router-dom';

function HomePage() {
    return (
        <div className='home'>
            <h1>Welcome to Our Project Page!</h1>
            <h3>Where do you want to go?</h3>
            <div>
                <Link to="/projects/create">
                    <button>Create Project</button>
                </Link>
                <Link to="/projects">
                    <button>View Projects</button>
                </Link>
            </div>
        </div>
    );
}

export default HomePage;