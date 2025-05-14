import { Canvas } from '@react-three/fiber';
import FloorWalls from './components/FloorAndWalls';
import Lights from './components/Lights';
import { OrbitControls } from '@react-three/drei';

function App() {
    return (
        <Canvas>
            <OrbitControls />
            <Lights />
            <FloorWalls />
        </Canvas>
    );
}

export default App
