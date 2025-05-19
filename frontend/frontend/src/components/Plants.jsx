import { useGLTF } from '@react-three/drei';
import { useEffect } from 'react';

export default function Plants() {
    const { scene } = useGLTF('/models/plants.gltf'); // VIKTIGT: absolut sökväg från public/

    return <primitive object={scene} scale={5} position={[-8.4, -3, 5]} rotation={[0, 0.4 * Math.PI, 0]} />;
}
