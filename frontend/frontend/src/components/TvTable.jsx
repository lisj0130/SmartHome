import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function TvTable() {
    const { scene } = useGLTF('/models/tvtable2.glb');

    useEffect(() => {
        console.log(scene); // Inspektera detta i DevTools för att hitta luckans namn
    }, [scene]);

    return <primitive object={scene} scale={0.07} position={[-8, -2, 0]} rotation={[0, 0.5 * Math.PI, 0]} />;
}
