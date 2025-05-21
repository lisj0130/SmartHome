import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function LampTable() {
    const { scene } = useGLTF('/models/lamptable.glb');

    useEffect(() => {
        console.log(scene); // Inspektera detta i DevTools för att hitta luckans namn
    }, [scene]);

    return <primitive object={scene} scale={5} position={[8.9, -3, 5]} rotation={[0, 1.5 * Math.PI, 0]} />;
}