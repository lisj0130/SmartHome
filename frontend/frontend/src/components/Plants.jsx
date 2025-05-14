import { useGLTF } from '@react-three/drei';

export default function Plants() {
    const { scene } = useGLTF('/models/plants.glb'); // VIKTIGT: absolut sökväg från public/

    return <primitive object={scene} scale={2} position={[-8, -2, 0]} />;
}
