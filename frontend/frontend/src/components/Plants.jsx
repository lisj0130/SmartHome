import { useGLTF } from '@react-three/drei';
import { useEffect } from 'react';

export default function Plants() {
    const { scene } = useGLTF('/models/plants.gltf'); // VIKTIGT: absolut sökväg från public/

    useEffect(() => {
        console.log(scene); // Inspektera detta i DevTools för att hitta luckans namn
    }, [scene]);

    return <primitive object={scene} scale={5} position={[-8, -2, 4]} />;
}
